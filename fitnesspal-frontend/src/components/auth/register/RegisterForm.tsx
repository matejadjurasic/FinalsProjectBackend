import React from 'react';
import Button from '../../common/Button';
import Input from '../../common/Input';
import { useRegister } from '../../../hooks/useRegister'; 
import ErrorDisplay from '../../error/ErrorDisplay';
import { GENDER } from '../../../lib/constants';

const RegisterForm: React.FC = () => {
  const { formData, handleChange, handleSubmit, loading, error, validationErrors } = useRegister();
  
  return (
    <div className="w-full max-w-md p-8 space-y-4 bg-gray-800 rounded shadow-md">
      <h2 className="text-2xl font-bold text-center text-white">Register</h2>
      <ErrorDisplay error={error} validationErrors={validationErrors} />
      <form onSubmit={handleSubmit} className="space-y-4">
        <Input
          label="Email"
          type="email"
          id="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          required
        />
        <Input
          label="Username"
          type="text"
          id="username"
          name="username"
          value={formData.username}
          onChange={handleChange}
          required
        />
        <Input
          label="Password"
          type="password"
          id="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          required
        />
        <Input
          label="Confirm Password"
          type="password"
          id="confirmPassword"
          name="confirmPassword"
          value={formData.confirmPassword}
          onChange={handleChange}
          required
        />
        <Input
          label="Name"
          type="text"
          id="name"
          name="name"
          value={formData.name}
          onChange={handleChange}
          required
        />
        <Input
          label="Height (cm)"
          type="number"
          id="height"
          name="height"
          value={formData.height}
          onChange={handleChange}
          required
        />
        <Input
          label="Weight (kg)"
          type="number"
          id="weight"
          name="weight"
          value={formData.weight}
          onChange={handleChange}
          required
        />
        <Input
          label="Age"
          type="number"
          id="age"
          name="age"
          value={formData.age}
          onChange={handleChange}
          required
        />
        <div>
          <label className="block text-sm font-medium text-gray-100">Gender:</label>
          <select
            name="gender"
            className="w-full px-3 py-2 mt-1 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
            value={formData.gender}
            onChange={handleChange}
            required
          >
            <option value={GENDER.MALE}>{GENDER.MALE}</option>
            <option value={GENDER.FEMALE}>{GENDER.FEMALE}</option>
          </select>
        </div>
        <Button type="submit" isLoading={loading}>
          Register
        </Button>
      </form>
    </div>
  );
};

export default RegisterForm;