import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, Meal } from '../constants/types';

type MealStoreState = {
    meals: Meal[] | null;
    loading: boolean;
    error: APIError | null;
    fetchMeals: () => Promise<void>;
    createMeal: (newMeal: Meal) => Promise<void>;
    updateMeal: (id: number, updatedMeal: Meal) => Promise<void>;
    deleteMeal: (id: number) => Promise<void>;
};

const useMealStore = create<MealStoreState>(set => ({
    meals: null,
    loading: false,
    error: null,

    fetchMeals: async () => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get('/meals'); // Adjust the endpoint as needed
            set({ meals: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    createMeal: async (newMeal: Meal) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/meals', newMeal); // Adjust the endpoint as needed
            set(state => ({ meals: [...(state.meals || []), response.data], loading: false }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateMeal: async (id: number, updatedMeal: Meal) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/meals/${id}`, updatedMeal); // Adjust the endpoint as needed
            set(state => ({
                meals: state.meals?.map(meal => (meal.id === id ? response.data : meal)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteMeal: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/meals/${id}`); // Adjust the endpoint as needed
            set(state => ({
                meals: state.meals?.filter(meal => meal.id !== id) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useMealStore;