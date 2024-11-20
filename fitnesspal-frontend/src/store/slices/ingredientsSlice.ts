import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { Ingredient, IngredientsState, APIError } from '../../lib/types';

const initialState: IngredientsState = {
    ingredients: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};

// Fetch all ingredients
export const fetchIngredients = createAsyncThunk<Ingredient[], void, { rejectValue: APIError }>(
    'ingredients/fetchIngredients',
    async (_, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Ingredient[]>('/ingredients');
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch ingredient by ID
export const fetchIngredientById = createAsyncThunk<Ingredient, number, { rejectValue: APIError }>(
    'ingredients/fetchIngredientById',
    async (id, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<Ingredient>(`/ingredients/${id}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Create a new ingredient
export const createIngredient = createAsyncThunk<number, Omit<Ingredient, 'id'>, { rejectValue: APIError }>(
    'ingredients/createIngredient',
    async (ingredientData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/ingredients', ingredientData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Update an existing ingredient
export const updateIngredient = createAsyncThunk<{ id: number; ingredientData: Partial<Ingredient> }, { id: number; ingredientData: Partial<Ingredient> }, { rejectValue: APIError }>(
    'ingredients/updateIngredient',
    async ({ id, ingredientData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/ingredients/${id}`, ingredientData);
            return { id, ingredientData };
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Delete an ingredient
export const deleteIngredient = createAsyncThunk<number, number, { rejectValue: APIError }>(
    'ingredients/deleteIngredient',
    async (id, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/ingredients/${id}`);
            return id;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

const ingredientsSlice = createSlice({
    name: 'ingredients',
    initialState,
    reducers: {
        clearIngredientsState(state) {
            state.ingredients = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchIngredients.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchIngredients.fulfilled, (state, action) => {
                state.loading = false;
                state.ingredients = action.payload;
            })
            .addCase(fetchIngredients.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchIngredientById.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchIngredientById.fulfilled, (state, action) => {
                state.loading = false;
                const existingIngredient = state.ingredients.find(ingredient => ingredient.id === action.payload.id);
                if (!existingIngredient) {
                    state.ingredients.push(action.payload);
                }
            })
            .addCase(fetchIngredientById.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createIngredient.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createIngredient.fulfilled, (state, action) => {
                const newIngredient: Ingredient = {
                    id: action.payload,
                    ...action.meta.arg
                };
                state.ingredients.push(newIngredient);
                state.loading = false;
                state.successMessage = 'Ingredient created successfully!';
            })
            .addCase(createIngredient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateIngredient.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateIngredient.fulfilled, (state, action) => {
                const { id, ingredientData } = action.payload;
                const updateIngredient = (ingredients: Ingredient[]) => {
                    const index = ingredients.findIndex(ingredient => ingredient.id === id);
                    if (index !== -1) {
                        ingredients[index] = { ...ingredients[index], ...ingredientData };
                    }
                };
                updateIngredient(state.ingredients);
                state.loading = false;
                state.successMessage = 'Ingredient updated successfully!';
            })
            .addCase(updateIngredient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteIngredient.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteIngredient.fulfilled, (state, action) => {
                state.ingredients = state.ingredients.filter(ingredient => ingredient.id !== action.payload);
                state.loading = false;
                state.successMessage = 'Ingredient deleted successfully!';
            })
            .addCase(deleteIngredient.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            });
    },
});

export const { clearIngredientsState } = ingredientsSlice.actions;
export default ingredientsSlice.reducer;