import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { User, UsersState, APIError } from '../../lib/types';

const initialState: UsersState = {
    users: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};

// Fetch all users
export const fetchUsers = createAsyncThunk<User[], void, { rejectValue: APIError }>(
    'users/fetchUsers',
    async (_, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<User[]>('/users');
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch user by ID
export const fetchUserById = createAsyncThunk<User, number, { rejectValue: APIError }>(
    'users/fetchUserById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<User>(`/users/${id}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Create a new user
export const createUser = createAsyncThunk<number, Omit<User, 'id'>, { rejectValue: APIError }>(
    'users/createUser',
    async (userData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/users', userData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Update an existing user
export const updateUser = createAsyncThunk<{ id: number; userData: Partial<User> }, { id: number; userData: Partial<User> }, { rejectValue: APIError }>(
    'users/updateUser',
    async ({ id, userData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/users/${id}`, userData);
            return { id, userData };
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Delete a user
export const deleteUser = createAsyncThunk<number, number, { rejectValue: APIError }>(
    'users/deleteUser',
    async (id, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/users/${id}`);
            return id;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

const usersSlice = createSlice({
    name: 'users',
    initialState,
    reducers: {
        clearUsersState(state) {
            state.users = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
        clearUserErrors(state) { 
            state.error = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchUsers.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchUsers.fulfilled, (state, action) => {
                state.loading = false;
                state.users = action.payload;
            })
            .addCase(fetchUsers.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchUserById.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchUserById.fulfilled, (state, action) => {
                state.loading = false;
                const existingUser = state.users.find(user => user.id === action.payload.id);
                if (!existingUser) {
                    state.users.push(action.payload);
                }
            })
            .addCase(fetchUserById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createUser.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createUser.fulfilled, (state, action) => {
                const newUser: User = {
                    id: action.payload,
                    ...action.meta.arg
                };
                state.users.push(newUser);
                state.loading = false;
                state.successMessage = 'User created successfully!';
            })
            .addCase(createUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateUser.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateUser.fulfilled, (state, action) => {
                const { id, userData } = action.payload;
                const updateUser = (users: User[]) => {
                    const index = users.findIndex(user => user.id === id);
                    if (index !== -1) {
                        users[index] = { ...users[index], ...userData };
                    }
                };
                updateUser(state.users);
                state.loading = false;
                state.successMessage = 'User updated successfully!';
            })
            .addCase(updateUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteUser.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteUser.fulfilled, (state, action) => {
                state.users = state.users.filter(user => user.id !== action.payload);
                state.loading = false;
                state.successMessage = 'User deleted successfully!';
            })
            .addCase(deleteUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            });
    },
});

export const { clearUsersState, clearUserErrors } = usersSlice.actions;
export default usersSlice.reducer;