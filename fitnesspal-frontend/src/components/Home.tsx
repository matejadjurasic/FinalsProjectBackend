import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useAuth } from '../hooks/useAuth';
import Navbar from './common/Navbar';
import { fetchGoals } from '../store/slices/goalsSlice';
import { fetchMeals } from '../store/slices/mealsSlice';
//import ProgressBar from './common/ProgressBar';
import { AppDispatch } from '../store';
import { useLocation } from 'react-router-dom';
import { fetchDailyWeightByDate,clearDailyWeightsState } from '../store/slices/dailyWeightsSlice';
import AddWeightModal from './common/AddWeightModal';
import { getTodaysDate, calculateMealTotals, getCurrentGoal, getWeightTrackingMessage } from '../lib/utils';
import { NAV_ITEMS } from '../lib/constants';
import HomeCarousel from './common/HomeCarousel';
import ProgressBar from 'react-bootstrap/ProgressBar'

export default function Home() {
  const dispatch = useDispatch<AppDispatch>();
  const location = useLocation();
  const { user } = useAuth();
  const goals = useSelector((state: any) => state.goals.goals);
  const dailyWeights = useSelector((state: any) => state.dailyWeights.dailyWeights);
  const meals = useSelector((state: any) => state.meals.meals);
  const loading = useSelector((state: any) => state.dailyWeights.loading);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [totals, setTotals] = useState({ calories: 0, protein: 0, fat: 0, carbs: 0, });
  const goal = getCurrentGoal(goals);

  useEffect(() => {
    dispatch(clearDailyWeightsState());
    dispatch(fetchGoals());
    const today = getTodaysDate();
    dispatch(fetchDailyWeightByDate(today));
    dispatch(fetchMeals(today));
  }, [dispatch,location]);

  useEffect(() => {
    setMessage(getWeightTrackingMessage(dailyWeights));
  },[dailyWeights]);

  useEffect(() => {
    const newTotals = calculateMealTotals(meals);
    setTotals(newTotals);
  }, [meals]);

  return (
    <div className="flex flex-col bg-gray-100">
        <Navbar items={NAV_ITEMS} />
      <div className="relative">
        <HomeCarousel />
      </div>
      <div className="flex justify-between p-8 bg-gray-800 shadow-md">
        <div className="w-3/5">
          <h2 className="mb-4 text-2xl font-bold text-gray-100">
            Welcome, {user?.name}!
          </h2>

          {/* Progress Bars Section */}
          <div className="mt-8">
            <h3 className="text-gray-100 text-xl font-semibold">Daily Progress</h3>
            <ProgressBar variant='success' className='mb-7' animated striped label="Calories" now={totals.calories} max={Math.round(goal.targetCalories)} />
            <ProgressBar variant='warning' className='mb-7' animated striped label="Protein" now={totals.protein} max={Math.round(goal.targetProtein)} />
            <ProgressBar variant='danger' className='mb-7' animated striped label="Fat" now={totals.fat} max={Math.round(goal.targetFats)} />
            <ProgressBar variant='info' className='mb-7' animated striped label="Carbs" now={totals.carbs} max={Math.round(goal.targetCarbs)} />
          </div>
        </div>

        {/* Add Daily Weight Section */}
        <div className="mt-8 ml-10 w-2/5">
          <h3 className="text-gray-100 text-xl font-semibold">Add Your Weight for the Day</h3>
          {!message && ( // Show button only if there are no daily weights and not loading
            <button
              onClick={() => setIsModalOpen(true)}
              className="mt-2 bg-blue-500 text-white rounded px-4 py-2"
            >
              Add Weight
            </button>
          )}
          {message && <p className="mt-2 text-green-600">{message}</p>}
        </div>
      </div>
      {/* Modal for Adding Weight */}
      <AddWeightModal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                date={new Date().toISOString()} // Today's date in ISO format
            />
    </div>
  );
}
