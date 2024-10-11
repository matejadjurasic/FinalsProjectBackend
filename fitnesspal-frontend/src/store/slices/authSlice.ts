import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import {
  User,
  AuthState,
  LoginCredentials,
  RegisterData,
  APIError,
} from '../../types/auth';

const tokenFromStorage = localStorage.getItem('token');
const userFromStorage = localStorage.getItem('user');


const initialState: AuthState = {
    user: userFromStorage ? JSON.parse(userFromStorage) : null,
    token: tokenFromStorage || null,
    loading: false,
    error: null,
    validationErrors: null,
    successMessage: null,
};

export const login = createAsyncThunk<User, LoginCredentials, { rejectValue: APIError }>(
  'auth/login',
  async (credentials, { rejectWithValue }) => {
    try {
      const response = await apiClient.post<User>('/auth/login', credentials);
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error as APIError);
    }
  }
);

export const register = createAsyncThunk<string, RegisterData, { rejectValue: APIError }>(
    'auth/register',
    async (registerData, { rejectWithValue }) => {
      try {
        const response = await apiClient.post<string>('/auth/register', registerData);
        return response.data;
      } catch (error: any) {
        return rejectWithValue(error as APIError);
      }
    }
);

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
      logout(state) {
        state.user = null;
        state.token = null;
        localStorage.removeItem('token');
        localStorage.removeItem('user');
      },
    },
    extraReducers: (builder) => {
      builder
        .addCase(login.pending, (state) => {
          state.loading = true;
          state.error = null;
          state.validationErrors = null; 
        })
        .addCase(login.fulfilled, (state, action: PayloadAction<User>) => {
          state.loading = false;
          state.user = action.payload;
          state.token = action.payload.token;
          state.successMessage = null;
          localStorage.setItem('token', action.payload.token);
          localStorage.setItem('user', JSON.stringify(action.payload));
        })
        .addCase(login.rejected, (state, action: PayloadAction<APIError | undefined>) => {
          state.loading = false;
          state.error = action.payload?.errorMessage || 'An error occurred.';
          state.validationErrors = action.payload?.validationErrors || null;
          state.successMessage = null;
        });

        builder
        .addCase(register.pending, (state) => {
            state.loading = true;
            state.error = null;
            state.validationErrors = null;
        })
        .addCase(register.fulfilled, (state, action: PayloadAction<string>) => {
            state.loading = false;
            state.successMessage = action.payload;
            state.error = null;
        })
        .addCase(register.rejected, (state, action: PayloadAction<APIError | undefined>) => {
            state.loading = false;
            state.error = action.payload?.errorMessage || 'An error occurred.';
            state.validationErrors = action.payload?.validationErrors || null;
            state.successMessage = null;
        });
    },
});
  
export const { logout } = authSlice.actions;
export default authSlice.reducer;