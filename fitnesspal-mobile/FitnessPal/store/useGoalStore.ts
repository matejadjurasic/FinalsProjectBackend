import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, Goal } from '../constants/types';

type GoalStoreState = {
    goals: Goal[] | null;
    loading: boolean;
    error: APIError | null;
    fetchGoals: () => Promise<void>;
    createGoal: (newGoal: Goal) => Promise<void>;
    updateGoal: (id: number, updatedGoal: Goal) => Promise<void>;
    deleteGoal: (id: number) => Promise<void>;
};

const useGoalStore = create<GoalStoreState>(set => ({
    goals: null,
    loading: false,
    error: null,

    fetchGoals: async () => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get('/goals'); // Adjust the endpoint as needed
            set({ goals: response.data, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    createGoal: async (newGoal: Goal) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/goals', newGoal); // Adjust the endpoint as needed
            set(state => ({ goals: [...(state.goals || []), response.data], loading: false }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateGoal: async (id: number, updatedGoal: Goal) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/goals/${id}`, updatedGoal); // Adjust the endpoint as needed
            set(state => ({
                goals: state.goals?.map(goal => (goal.id === id ? response.data : goal)) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteGoal: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/goals/${id}`); // Adjust the endpoint as needed
            set(state => ({
                goals: state.goals?.filter(goal => goal.id !== id) || null,
                loading: false,
            }));
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useGoalStore;