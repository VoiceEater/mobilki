import api from './api';

export const getWishlist = (userId) => api.get(`/wishlists/user/${userId}`);
export const addToWishlist = (data) => api.post('/wishlists', data);
export const removeFromWishlist = (id) => api.delete(`/wishlists/${id}`);