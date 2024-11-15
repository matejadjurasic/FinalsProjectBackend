import { create } from 'zustand';
import apiClient from '../api/axios';
import { APIError, User } from '../constants/types';

type UserStoreState = {
    user: User | null;
    loading: boolean;
    error: APIError | null;
    login: (email: string, password: string) => Promise<void>;
    register: (username: string, password: string, email: string, name: string, height: number, weight: number, age: number, gender: string) => Promise<void>;
    logout: () => void;
    fetchUser: (id: number) => Promise<void>; // Fetch user by ID
    updateUser: (id: number, updatedUser: User) => Promise<void>; // Update user information
    deleteUser: (id: number) => Promise<void>; // Delete user account
};

const useUserStore = create<UserStoreState>((set) => ({
    user: null,
    loading: false,
    error: null,

    login: async (email: string, password: string) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.post('/login', { email, password });
            const user: User = response.data; 
            set({ user, loading: false });
            localStorage.setItem('token', user.token); 
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    register: async (username: string, password: string, email: string, name: string, height: number, weight: number, age: number, gender: string) => {
        set({ loading: true, error: null });
        try {
            await apiClient.post('/register', {
                username,
                password,
                email,
                name,
                height,
                weight,
                age,
                gender,
            });
            // Optionally, you can log in the user immediately after registration
            const response = await apiClient.post('/login', { email, password });
            const user: User = response.data; 
            set({ user, loading: false });
            localStorage.setItem('token', user.token); 
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    logout: () => {
        set({ user: null });
        localStorage.removeItem('token'); 
    },

    fetchUser: async (id: number) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.get(`/users/${id}`); // Adjust the endpoint as needed
            const user: User = response.data;
            set({ user, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    updateUser: async (id: number, updatedUser: User) => {
        set({ loading: true, error: null });
        try {
            const response = await apiClient.put(`/users/${id}`, updatedUser); // Adjust the endpoint as needed
            const user: User = response.data;
            set({ user, loading: false });
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },

    deleteUser: async (id: number) => {
        set({ loading: true, error: null });
        try {
            await apiClient.delete(`/users/${id}`); // Adjust the endpoint as needed
            set({ user: null, loading: false }); // Optionally clear user data after deletion
            localStorage.removeItem('token'); // Clear token on user deletion
        } catch (error) {
            set({ error: error as APIError, loading: false });
        }
    },
}));

export default useUserStore;