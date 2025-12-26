import React, { useState, useEffect } from 'react';
import { createTransaction, getCategories, getUsers } from '../api/api';
import { useNavigate } from 'react-router-dom';

function AddTransaction() {
  const navigate = useNavigate();
  const [categories, setCategories] = useState([]);
  const [users, setUsers] = useState([]);
  const [formData, setFormData] = useState({
    amount: '',
    date: '',
    userId: '',
    categoryId: ''
  });
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const categoriesRes = await getCategories();
      const usersRes = await getUsers();
      setCategories(categoriesRes.data);
      setUsers(usersRes.data);
    } catch (err) {
      setError('Failed to load data');
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      await createTransaction({
        amount: parseFloat(formData.amount),
        date: formData.date,
        userId: parseInt(formData.userId),
        categoryId: parseInt(formData.categoryId)
      });
      navigate('/transactions');
    } catch (err) {
      setError('Failed to create transaction');
      setLoading(false);
    }
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  return (
    <div className="container">
      <h1>➕ Add Transaction</h1>

      {error && <div className="error">{error}</div>}

      <form onSubmit={handleSubmit} className="form-card">
        <div className="form-group">
          <label>Amount</label>
          <input
            type="number"
            name="amount"
            step="0.01"
            value={formData.amount}
            onChange={handleChange}
            className="input"
            required
          />
        </div>

        <div className="form-group">
          <label>Date</label>
          <input
            type="datetime-local"
            name="date"
            value={formData.date}
            onChange={handleChange}
            className="input"
            required
          />
        </div>

        <div className="form-group">
          <label>User</label>
          <select name="userId" value={formData.userId} onChange={handleChange} className="input" required>
            <option value="">Select User</option>
            {users.map(user => (
              <option key={user.id} value={user.id}>{user.name}</option>
            ))}
          </select>
        </div>

        <div className="form-group">
          <label>Category</label>
          <select name="categoryId" value={formData.categoryId} onChange={handleChange} className="input" required>
            <option value="">Select Category</option>
            {categories.map(category => (
              <option key={category.id} value={category.id}>{category.name}</option>
            ))}
          </select>
        </div>

        <div className="button-group">
          <button type="submit" className="btn btn-primary" disabled={loading}>
            {loading ? 'Creating...' : 'Create Transaction'}
          </button>
          <button type="button" onClick={() => navigate('/transactions')} className="btn btn-secondary">
            Cancel
          </button>
        </div>
      </form>
    </div>
  );
}

export default AddTransaction;