import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import apiClient from '../../api/axios';
import { MealItem, MealItemsState, APIError } from '../../lib/types';

const initialState: MealItemsState = {
    mealItems: [],
    loading: false,
    error: null,
    successMessage: null,
    validationErrors: null,
};

// Fetch meal items by meal ID
export const fetchMealItemsByMealId = createAsyncThunk<MealItem[], number, { rejectValue: APIError }>(
    'mealItems/fetchMealItemsByMealId',
    async (mealId, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<MealItem[]>(`/mealitems/${mealId}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Fetch meal item by meal ID and ingredient ID
export const fetchMealItemByIds = createAsyncThunk<MealItem, { mealId: number; ingredientId: number }, { rejectValue: APIError }>(
    'mealItems/fetchMealItemByIds',
    async ({ mealId, ingredientId }, { rejectWithValue }) => {
        try {
            const response = await apiClient.get<MealItem>(`/mealitems/${mealId}/${ingredientId}`);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Create a new meal item
export const createMealItem = createAsyncThunk<number, MealItem, { rejectValue: APIError }>(
    'mealItems/createMealItem',
    async (mealItemData, { rejectWithValue }) => {
        try {
            const response = await apiClient.post<number>('/mealitems', mealItemData);
            return response.data;
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Update an existing meal item
export const updateMealItem = createAsyncThunk<{ mealId: number; ingredientId: number; mealItemData: Partial<MealItem> }, { mealId: number; ingredientId: number; mealItemData: Partial<MealItem> }, { rejectValue: APIError }>(
    'mealItems/updateMealItem',
    async ({ mealId, ingredientId, mealItemData }, { rejectWithValue }) => {
        try {
            await apiClient.put(`/mealitems/${mealId}/${ingredientId}`, mealItemData);
            return { mealId, ingredientId, mealItemData };
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

// Delete a meal item
export const deleteMealItem = createAsyncThunk<number, { mealId: number; ingredientId: number }, { rejectValue: APIError }>(
    'mealItems/deleteMealItem',
    async ({ mealId, ingredientId }, { rejectWithValue }) => {
        try {
            await apiClient.delete(`/mealitems/${mealId}/${ingredientId}`);
            return ingredientId; // Return the ingredient ID for filtering
        } catch (error: any) {
            return rejectWithValue(error as APIError);
        }
    }
);

const mealItemsSlice = createSlice({
    name: 'mealItems',
    initialState,
    reducers: {
        clearMealItemsState(state) {
            state.mealItems = [];
            state.loading = false;
            state.error = null;
            state.successMessage = null;
            state.validationErrors = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchMealItemsByMealId.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchMealItemsByMealId.fulfilled, (state, action) => {
                state.loading = false;
                state.mealItems = action.payload;
            })
            .addCase(fetchMealItemsByMealId.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(fetchMealItemByIds.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(fetchMealItemByIds.fulfilled, (state, action) => {
                state.loading = false;
                const existingItem = state.mealItems.find(item => item.mealId === action.payload.mealId && 
                                                            item.ingredientId === action.payload.ingredientId);
                if (!existingItem) {
                    state.mealItems.push(action.payload);
                }
            })
            .addCase(fetchMealItemByIds.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(createMealItem.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(createMealItem.fulfilled, (state, action) => {
                const newMealItem: MealItem = {
                    ...action.meta.arg
                };
                state.mealItems.push(newMealItem);
                state.loading = false;
                state.successMessage = 'Meal item created successfully!';
            })
            .addCase(createMealItem.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(updateMealItem.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(updateMealItem.fulfilled, (state, action) => {
                const { mealId, ingredientId, mealItemData } = action.payload;
                const updateItem = (items: MealItem[]) => {
                    const index = items.findIndex(item => item.mealId === mealId && item.ingredientId === ingredientId);
                    if (index !== -1) {
                        items[index] = { ...items[index], ...mealItemData };
                    }
                };
                updateItem(state.mealItems);
                state.loading = false;
                state.successMessage = 'Meal item updated successfully!';
            })
            .addCase(updateMealItem.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            })
            .addCase(deleteMealItem.pending, (state) => {
                state.loading = true;
                state.error = null;
                state.validationErrors = null;
            })
            .addCase(deleteMealItem.fulfilled, (state, action) => {
                state.mealItems = state.mealItems.filter(item => item.ingredientId !== action.payload);
                state.loading = false;
                state.successMessage = 'Meal item deleted successfully!';
            })
            .addCase(deleteMealItem.rejected, (state, action) => {
                state.loading = false;
                state.error = action.payload?.errorMessage || 'An error occurred.';
                state.validationErrors = action.payload?.validationErrors || null;
            });
    },
});

export const { clearMealItemsState } = mealItemsSlice.actions;
export default mealItemsSlice.reducer;