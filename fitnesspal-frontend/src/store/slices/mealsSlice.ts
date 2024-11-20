import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { Meal, MealsState, APIError } from '../../lib/types';

const initialState: MealsState = {
    meals: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};

// Fetch all meals
export const fetchMeals = createAsyncThunk<Meal[], string, { rejectValue: APIError }>(
    'meals/fetchMeals',
    async (date, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Meal[]>(`/meals?date=${date}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch a meal by ID
export const fetchMealById = createAsyncThunk<Meal, number, { rejectValue: APIError }>(
    'meals/fetchMealById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Meal>(`/meals/${id}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Create a new meal
export const createMeal = createAsyncThunk<number, Omit<Meal, 'id'>, { rejectValue: APIError }>(
    'meals/createMeal',
    async (mealData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/meals', mealData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Update an existing meal
export const updateMeal = createAsyncThunk<{ id: number; mealData: Partial<Meal> }, { id: number; mealData: Partial<Meal> }, { rejectValue: APIError }>(
    'meals/updateMeal',
    async ({ id, mealData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/meals/${id}`, mealData);
            return { id, mealData };
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Delete a meal
export const deleteMeal = createAsyncThunk<number, number, { rejectValue: APIError }>(
    'meals/deleteMeal',
    async (id, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/meals/${id}`);
            return id;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

const mealsSlice = createSlice({
    name: 'meals',
    initialState,
    reducers: {
        clearMealsState(state) {
            state.meals = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchMeals.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchMeals.fulfilled, (state, action) => {
                state.loading = false;
                state.meals = action.payload;
            })
            .addCase(fetchMeals.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchMealById.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchMealById.fulfilled, (state, action) => {
                state.loading = false;
                //const existingMeal = state.meals.find(meal => meal.id === action.payload.id);
                //if (!existingMeal) {
                //    state.meals.push(action.payload);
                //}
                const existingMealIndex = state.meals.findIndex(meal => meal.id === action.payload.id);
                if (existingMealIndex !== -1) {
                    // Replace the existing meal
                    state.meals[existingMealIndex] = action.payload;
                } else {
                    // Push the new meal if it doesn't exist
                    state.meals.push(action.payload);
                }
            })
            .addCase(fetchMealById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createMeal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createMeal.fulfilled, (state, action) => {
                const newMeal: Meal = {
                    id: action.payload,
                    ...action.meta.arg
                };
                state.meals.push(newMeal);
                state.loading = false;
                state.successMessage = 'Meal created successfully!';
            })
            .addCase(createMeal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateMeal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateMeal.fulfilled, (state, action) => {
                const { id, mealData } = action.payload;
                const updateMeal = (meals: Meal[]) => {
                    const index = meals.findIndex(meal => meal.id === id);
                    if (index !== -1) {
                        meals[index] = { ...meals[index], ...mealData };
                    }
                };
                updateMeal(state.meals);
                state.loading = false;
                state.successMessage = 'Meal updated successfully!';
            })
            .addCase(updateMeal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteMeal.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteMeal.fulfilled, (state, action) => {
                state.meals = state.meals.filter(meal => meal.id !== action.payload);
                state.loading = false;
                state.successMessage = 'Meal deleted successfully!';
            })
            .addCase(deleteMeal.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            });
    },
});

export const { clearMealsState } = mealsSlice.actions;
export default mealsSlice.reducer;