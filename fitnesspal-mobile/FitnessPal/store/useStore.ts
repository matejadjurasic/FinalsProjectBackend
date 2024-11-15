import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError } from '../constants/types';

type StoreState = {
    data: any | null;
    loading: boolean;
    error: APIError | null;
    fetchData: () => Promise<void>;
    postData: (newData: any) => Promise<void>;
    putData: (id: number, updatedData: any) => Promise<void>;
    deleteData: (id: number) => Promise<void>;
};

const useStore = create<StoreState>( set => ({
    data: null,
    loading: false,
    error: null,

    fetchData: async () => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get('/data'); // Adjust the endpoint as needed
            set({ data: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    postData: async (newData: any) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/data', newData); // Adjust the endpoint as needed
            set({ data: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    putData: async (id: number, updatedData: any) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/data/${id}`, updatedData); // Adjust the endpoint as needed
            set({ data: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteData: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/data/${id}`); // Adjust the endpoint as needed
            set({ data: null, loading: false }); // Optionally update state after deletion
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useStore;