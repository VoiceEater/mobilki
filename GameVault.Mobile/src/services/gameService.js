import api from './api';

export const getGames = () => api.get('/games');
export const getGameById = (id) => api.get(`/games/${id}`);
export const createGame = (data) => api.post('/games', data);
export const updateGame = (id, data) => api.put(`/games/${id}`, data);
export const deleteGame = (id) => api.delete(`/games/${id}`);