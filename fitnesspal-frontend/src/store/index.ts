import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slices/authSlice';
import goalReducer from './slices/goalsSlice';
import mealReducer from './slices/mealsSlice';
import dailyWeightReducer from './slices/dailyWeightsSlice';
import mealItemReducer from './slices/mealItemsSlice';
import ingredientReducer from './slices/ingredientsSlice';
import userReducer from './slices/usersSlice';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    goals: goalReducer,
    meals: mealReducer,
    dailyWeights: dailyWeightReducer,
    mealItems: mealItemReducer,
    users: userReducer,
    ingredients: ingredientReducer
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;