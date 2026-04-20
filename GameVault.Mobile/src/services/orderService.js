import api from './api';

export const getOrders = () => api.get('/orders');
export const getOrdersByUser = (userId) => api.get(`/orders/user/${userId}`);
export const createOrder = (data) => api.post('/orders', data);
export const deleteOrder = (id) => api.delete(`/orders/${id}`);