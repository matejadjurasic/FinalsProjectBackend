import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch,useSelector } from 'react-redux';
import { calculatorGoal } from '../store/slices/goalsSlice';
import { AppDispatch,RootState } from '../store';
import { GENDER, ACTIVITY_LEVEL, GOAL_TYPE } from '../lib/constants';

export const useOnboarding = () => {
    const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const { loading, error, validationErrors } = useSelector((state: RootState) => state.goals);
  const [formData, setFormData] = useState({
    weight: 0,
    height: 0,
    age: 0,
    gender: GENDER.MALE,
    activityLevel: ACTIVITY_LEVEL.MODERATE,
    type: GOAL_TYPE.WEIGHTLOSS,
    targetWeight: 0,
  });

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem('user') || '{}');
    if (user) {
      setFormData((prev) => ({
        ...prev,
        weight: user.weight,
        height: user.height,
        age: user.age,
        gender: user.gender,
      }));
    }
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await dispatch(calculatorGoal({...formData, targetWeight: Number(formData.targetWeight)})).unwrap();
      navigate('/', { replace: true });
    } catch (err) {
    }
  };

  return {
    formData,
    handleChange,
    handleSubmit,
    error,
    validationErrors,
    loading
  };
};