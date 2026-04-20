import api from './api';

export const getReviewsByGame = (gameId) => api.get(`/reviews/game/${gameId}`);
export const createReview = (data) => api.post('/reviews', data);
export const updateReview = (id, data) => api.put(`/reviews/${id}`, data);
export const deleteReview = (id) => api.delete(`/reviews/${id}`);