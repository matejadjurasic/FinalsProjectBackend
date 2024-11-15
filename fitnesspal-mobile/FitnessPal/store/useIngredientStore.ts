import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, Ingredient } from '../constants/types';

type IngredientStoreState = {
    ingredients: Ingredient[] | null;
    loading: boolean;
    error: APIError | null;
    fetchIngredients: () => Promise<void>;
    createIngredient: (newIngredient: Ingredient) => Promise<void>;
    updateIngredient: (id: number, updatedIngredient: Ingredient) => Promise<void>;
    deleteIngredient: (id: number) => Promise<void>;
};

const useIngredientStore = create<IngredientStoreState>(set => ({
    ingredients: null,
    loading: false,
    error: null,

    fetchIngredients: async () => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get('/ingredients'); // Adjust the endpoint as needed
            set({ ingredients: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    createIngredient: async (newIngredient: Ingredient) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/ingredients', newIngredient); // Adjust the endpoint as needed
            set(state => ({ ingredients: [...(state.ingredients || []), response.data], loading: false }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateIngredient: async (id: number, updatedIngredient: Ingredient) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/ingredients/${id}`, updatedIngredient); // Adjust the endpoint as needed
            set(state => ({
                ingredients: state.ingredients?.map(ingredient => (ingredient.id === id ? response.data : ingredient)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteIngredient: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/ingredients/${id}`); // Adjust the endpoint as needed
            set(state => ({
                ingredients: state.ingredients?.filter(ingredient => ingredient.id !== id) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useIngredientStore;