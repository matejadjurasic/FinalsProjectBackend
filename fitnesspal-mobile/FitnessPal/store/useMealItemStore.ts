import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, MealItem } from '../constants/types';

type MealItemStoreState = {
    mealItems: MealItem[] | null;
    loading: boolean;
    error: APIError | null;
    fetchMealItems: (mealId: number) => Promise<void>;
    createMealItem: (newMealItem: MealItem) => Promise<void>;
    updateMealItem: (mealId: number, ingredientId: number, updatedMealItem: MealItem) => Promise<void>;
    deleteMealItem: (mealId: number, ingredientId: number) => Promise<void>;
};

const useMealItemStore = create<MealItemStoreState>(set => ({
    mealItems: null,
    loading: false,
    error: null,

    fetchMealItems: async (mealId: number) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get(`/mealitems/${mealId}`); // Adjust the endpoint as needed
            set({ mealItems: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    createMealItem: async (newMealItem: MealItem) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/mealitems', newMealItem); // Adjust the endpoint as needed
            set(state => ({ mealItems: [...(state.mealItems || []), response.data], loading: false }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateMealItem: async (mealId: number, ingredientId: number, updatedMealItem: MealItem) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/mealitems/${mealId}/${ingredientId}`, updatedMealItem); // Adjust the endpoint as needed
            set(state => ({
                mealItems: state.mealItems?.map(item => 
                    (item.mealId === mealId && item.ingredientId === ingredientId ? response.data : item)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteMealItem: async (mealId: number, ingredientId: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/mealitems/${mealId}/${ingredientId}`); // Adjust the endpoint as needed
            set(state => ({
                mealItems: state.mealItems?.filter(item => 
                    !(item.mealId === mealId && item.ingredientId === ingredientId)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useMealItemStore;