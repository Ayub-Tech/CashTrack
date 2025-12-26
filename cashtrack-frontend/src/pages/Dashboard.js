import React, { useState, useEffect } from 'react';
import { getCategories, getTransactions } from '../api/api';
import { Link } from 'react-router-dom';
import { PieChart, Pie, Cell, ResponsiveContainer, Legend, Tooltip } from 'recharts';

const COLORS = ['#667eea', '#764ba2', '#f093fb', '#4facfe', '#43e97b', '#fa709a', '#fee140', '#30cfd0'];

function Dashboard() {
  const [stats, setStats] = useState({
    totalCategories: 0,
    totalTransactions: 0,
    totalAmount: 0,
    loading: true,
    error: null
  });
  const [chartData, setChartData] = useState([]);

  useEffect(() => {
    fetchDashboardData();
  }, []);

  const fetchDashboardData = async () => {
    try {
      const [categoriesRes, transactionsRes] = await Promise.all([
        getCategories(),
        getTransactions()
      ]);

      const totalAmount = transactionsRes.data.reduce((sum, t) => sum + t.amount, 0);

      // Calculate spending by category for pie chart
      const categoryTotals = {};
      transactionsRes.data.forEach(transaction => {
        const category = categoriesRes.data.find(c => c.id === transaction.categoryId);
        const categoryName = category ? category.name : 'Unknown';
        
        if (!categoryTotals[categoryName]) {
          categoryTotals[categoryName] = 0;
        }
        categoryTotals[categoryName] += transaction.amount;
      });

      // Convert to chart data format
      const pieData = Object.keys(categoryTotals).map(name => ({
        name,
        value: categoryTotals[name]
      }));

      setChartData(pieData);
      setStats({
        totalCategories: categoriesRes.data.length,
        totalTransactions: transactionsRes.data.length,
        totalAmount: totalAmount,
        loading: false,
        error: null
      });
    } catch (error) {
      setStats(prev => ({
        ...prev,
        loading: false,
        error: 'Failed to load dashboard data'
      }));
    }
  };

  if (stats.loading) {
    return <div className="container">Loading...</div>;
  }

  if (stats.error) {
    return <div className="container error">{stats.error}</div>;
  }

  return (
    <div className="container">
      <h1>💰 CashTrack Dashboard</h1>
      
      <div className="stats-grid">
        <div className="stat-card">
          <h3>Categories</h3>
          <p className="stat-number">{stats.totalCategories}</p>
          <Link to="/categories" className="stat-link">View All →</Link>
        </div>

        <div className="stat-card">
          <h3>Transactions</h3>
          <p className="stat-number">{stats.totalTransactions}</p>
          <Link to="/transactions" className="stat-link">View All →</Link>
        </div>

        <div className="stat-card">
          <h3>Total Amount</h3>
          <p className="stat-number">${stats.totalAmount.toFixed(2)}</p>
          <Link to="/add-transaction" className="stat-link">Add New →</Link>
        </div>
      </div>

      {chartData.length > 0 && (
        <div className="chart-container">
          <h2>📊 Spending by Category</h2>
          <ResponsiveContainer width="100%" height={400}>
            <PieChart>
              <Pie
                data={chartData}
                cx="50%"
                cy="50%"
                labelLine={false}
                label={({ name, percent }) => `${name}: ${(percent * 100).toFixed(0)}%`}
                outerRadius={120}
                fill="#8884d8"
                dataKey="value"
              >
                {chartData.map((entry, index) => (
                  <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
              </Pie>
              <Tooltip formatter={(value) => `$${value.toFixed(2)}`} />
              <Legend />
            </PieChart>
          </ResponsiveContainer>
        </div>
      )}

      <div className="quick-actions">
        <h2>Quick Actions</h2>
        <div className="button-group">
          <Link to="/add-transaction" className="btn btn-primary">+ New Transaction</Link>
          <Link to="/categories" className="btn btn-secondary">Manage Categories</Link>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;