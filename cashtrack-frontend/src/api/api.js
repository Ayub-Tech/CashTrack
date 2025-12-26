import axios from 'axios';

const API_BASE_URL = 'https://localhost:7256/api';

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getCategories = () => api.get('/category');
export const getCategory = (id) => api.get('/category/' + id);
export const createCategory = (data) => api.post('/category', data);
export const updateCategory = (id, data) => api.put('/category/' + id, data);
export const deleteCategory = (id) => api.delete('/category/' + id);

export const getTransactions = () => api.get('/transaction');
export const getTransaction = (id) => api.get('/transaction/' + id);
export const createTransaction = (data) => api.post('/transaction', data);
export const updateTransaction = (id, data) => api.put('/transaction/' + id, data);
export const deleteTransaction = (id) => api.delete('/transaction/' + id);

export const getUsers = () => api.get('/user');
export const getUser = (id) => api.get('/user/' + id);
export const createUser = (data) => api.post('/user', data);
export const updateUser = (id, data) => api.put('/user/' + id, data);
export const deleteUser = (id) => api.delete('/user/' + id);

export default api;