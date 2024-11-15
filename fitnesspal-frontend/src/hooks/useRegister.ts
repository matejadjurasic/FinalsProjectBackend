import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { register,login } from '../store/slices/authSlice';
import { AppDispatch } from '../store';
import { RegisterData } from '../lib/types';
import { useAuth } from './useAuth';
import { GENDER } from '../lib/constants';

export const useRegister = () => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { loading, error, validationErrors } = useAuth();
  const [formData, setFormData] = useState<RegisterData>({
    email: '',
    username: '',
    password: '',
    confirmPassword: '',
    name: '',
    height: 0,
    weight: 0,
    age: 0,
    gender: GENDER.MALE,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    //dispatch(register(formData));
    try {
        await dispatch(register(formData)).unwrap();
        await dispatch(login({ email: formData.email, password: formData.password })).unwrap();
        navigate('/onboarding', { replace: true });
      } catch (err) {
      }
  };

  return {
    formData,
    handleChange,
    handleSubmit,
    loading,
    error,
    validationErrors,
  };
};