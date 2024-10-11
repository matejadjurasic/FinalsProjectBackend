import React, { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { register } from '../store/slices/authSlice';
import { AppDispatch } from '../store';
import { useNavigate } from 'react-router-dom';
import Button from './common/Button';
import { useAuth } from '../hooks/useAuth';
import Input from './common/Input';

export default function Register(){
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { loading, error, validationErrors, token } = useAuth();
  const [isRegistered, setIsRegistered] = useState(false);

  const [formData, setFormData] = useState({
    email: '',
    username: '',
    password: '',
    confirmPassword: '',
    name: '',
    height: '',
    weight: '',
    age: '',
    gender: '',
  });

  useEffect(() => {
    if (token) {
      navigate('/', { replace: true });
    }
  }, [token, navigate]);

  useEffect(() => {
    if (isRegistered) {
      navigate('/login', { replace: true, state: { successMessage: 'Registration successful. Please log in.' }});
    }
  }, [isRegistered, navigate]);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    const height = parseFloat(formData.height);
    const weight = parseFloat(formData.weight);
    const age = parseInt(formData.age, 10);

    try {
      await dispatch(
        register({
          ...formData,
          height,
          weight,
          age,
        })
      ).unwrap();
      setIsRegistered(true);
    } catch (err) {
    }
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="w-full max-w-lg p-8 space-y-4 bg-white rounded shadow-md">
        <h2 className="text-2xl font-bold text-center text-gray-800">Register</h2>
        {error && <p className="text-red-500">{error}</p>}
        {validationErrors &&
          Object.entries(validationErrors).map(([field, messages]) => (
            <div key={field} className="text-red-500">
              <strong>{field}:</strong> {messages.join(', ')}
            </div>
          ))}
        <form onSubmit={handleSubmit} className="space-y-4">
          {/* Email */}
          <Input
          label="Email"
          type="email"
          id="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
          {/* Username */}
          <Input
          label="Username"
          type="text"
          id="username"
          value={formData.username}
          onChange={handleChange}
          required
        /> 
          {/* Password */}
          <Input
          label="Password"
          type="password"
          id="password"
          value={formData.password}
          onChange={handleChange}
          required
        />
          {/* Confirm Password */}
          <Input
          label="Confirm Password"
          type="password"
          id="confirmPassword"
          value={formData.confirmPassword}
          onChange={handleChange}
          required
        />
          {/* Name */}
          <Input
          label="Name"
          type="text"
          id="name"
          value={formData.name}
          onChange={handleChange}
          required
        />
          {/* Height */}
          <Input
          label="Height (cm)"
          type="number"
          id="height"
          value={formData.height}
          onChange={handleChange}
          required
        />
          {/* Weight */}
          <Input
          label="Weight (kg)"
          type="number"
          id="weight"
          value={formData.weight}
          onChange={handleChange}
          required
        />
          {/* Age */}
          <Input
          label="Age"
          type="number"
          id="age"
          value={formData.age}
          onChange={handleChange}
          required
        />
          {/* Gender */}
          <div>
            <label className="block text-sm font-medium text-gray-700">
              Gender:
            </label>
            <select
              name="gender"
              className="w-full px-3 py-2 mt-1 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
              value={formData.gender}
              onChange={handleChange}
              required
            >
              <option value="Male">Male</option>
              <option value="Female">Female</option>
            </select>
          </div>
          {/* Submit */}
          <Button type="submit" isLoading={loading}>
            Register
          </Button>
          <p className="text-sm text-center text-gray-600">
            Already have an account?{' '}
            <a
              href="/login"
              className="text-blue-600 hover:underline hover:text-blue-800"
            >
              Login
            </a>
          </p>
        </form>
      </div>
    </div>
  );
}
