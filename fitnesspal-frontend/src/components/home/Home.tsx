import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import Navbar from '../common/Navbar';
import { fetchGoals } from '../../store/slices/goalsSlice';
import { fetchMeals } from '../../store/slices/mealsSlice';
import { AppDispatch } from '../../store';
import { useLocation } from 'react-router-dom';
import { fetchDailyWeightByDate,clearDailyWeightsState, clearDailyWeightErrors } from '../../store/slices/dailyWeightsSlice';
import AddWeightModal from './AddWeightModal';
import { getTodaysDate, calculateMealTotals, getWeightTrackingMessage } from '../../lib/utils';
import { NAV_ITEMS } from '../../lib/constants';
import HomeCarousel from './HomeCarousel';
import WelcomeText from './WelcomeText';
import DailyProgress from './DailyProgress';
import DailyWeight from './DailyWeight';

export default function Home() {
  const dispatch = useDispatch<AppDispatch>();
  const location = useLocation();
  const dailyWeights = useSelector((state: any) => state.dailyWeights.dailyWeights);
  const meals = useSelector((state: any) => state.meals.meals);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [totals, setTotals] = useState({ calories: 0, protein: 0, fat: 0, carbs: 0, });

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

  const OpenModal = () => {
    dispatch(clearDailyWeightErrors());
    setIsModalOpen(true);
  };

  return (
    <div className="flex flex-col bg-gray-100">
        <Navbar items={NAV_ITEMS} />
      <div className="relative">
        <HomeCarousel />
      </div>
      <div className="flex justify-between p-8 bg-gray-800 shadow-md">
        <div className="w-3/5">
          <WelcomeText />
          <DailyProgress totals={totals}/>
        </div>
        <DailyWeight message={message} onAddWeight={() => OpenModal()} />
      </div>
      <AddWeightModal
                isOpen={isModalOpen}
                onClose={() => setIsModalOpen(false)}
                date={new Date().toISOString()}
            />
    </div>
  );
}
