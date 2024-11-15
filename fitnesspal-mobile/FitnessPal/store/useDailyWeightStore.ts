import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, DailyWeight } from '../constants/types';

type DailyWeightStoreState = {
    dailyWeights: DailyWeight[] | null;
    loading: boolean;
    error: APIError | null;
    fetchDailyWeights: () => Promise<void>;
    createDailyWeight: (newWeight: DailyWeight) => Promise<void>;
    updateDailyWeight: (id: number, updatedWeight: DailyWeight) => Promise<void>;
    deleteDailyWeight: (id: number) => Promise<void>;
};

const useDailyWeightStore = create<DailyWeightStoreState>(set => ({
    dailyWeights: null,
    loading: false,
    error: null,

    fetchDailyWeights: async () => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get('/dailyweights'); // Adjust the endpoint as needed
            set({ dailyWeights: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    createDailyWeight: async (newWeight: DailyWeight) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/dailyweights', newWeight); // Adjust the endpoint as needed
            set(state => ({ dailyWeights: [...(state.dailyWeights || []), response.data], loading: false }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateDailyWeight: async (id: number, updatedWeight: DailyWeight) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/dailyweights/${id}`, updatedWeight); // Adjust the endpoint as needed
            set(state => ({
                dailyWeights: state.dailyWeights?.map(weight => (weight.id === id ? response.data : weight)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteDailyWeight: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/dailyweights/${id}`); // Adjust the endpoint as needed
            set(state => ({
                dailyWeights: state.dailyWeights?.filter(weight => weight.id !== id) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useDailyWeightStore;