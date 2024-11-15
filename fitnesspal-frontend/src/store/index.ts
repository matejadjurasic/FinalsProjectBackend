import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slices/authSlice';
import goalReducer from './slices/goalsSlice';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    goals: goalReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;