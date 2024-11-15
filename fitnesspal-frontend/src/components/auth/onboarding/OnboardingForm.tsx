import React, {useEffect} from 'react';
import Button from '../../common/Button';
import Input from '../../common/Input';
import { useOnboarding } from '../../../hooks/useOnboarding';
import ErrorDisplay from '../../error/ErrorDisplay';
import { ACTIVITY_LEVEL, GOAL_TYPE } from '../../../lib/constants';

const LoginForm: React.FC = () => {
    const { formData, handleChange, handleSubmit, error, validationErrors } = useOnboarding();
    useEffect(() => {
        console.log(validationErrors);
      }, [validationErrors]);

  return (
    <div className="w-full max-w-md p-8 space-y-4 bg-gray-800 rounded shadow-md">
        <h2 className="text-2xl font-bold text-center text-white">Set Your Initial Goal</h2>
        <ErrorDisplay error={error} validationErrors={validationErrors} />
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-gray-100">Activity Level:</label>
            <select
              name="activityLevel"
              className="w-full px-3 py-2 mt-1 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
              value={formData.activityLevel}
              onChange={handleChange}
              required
            >
              {Object.values(ACTIVITY_LEVEL).map((level) => (
                <option key={level} value={level}>{level}</option>
              ))}
            </select>
          </div>
          <div>
            <label className="block text-sm font-medium text-gray-100">Goal Type:</label>
            <select
              name="type"
              className="w-full px-3 py-2 mt-1 border rounded-md focus:outline-none focus:ring focus:ring-blue-200"
              value={formData.type}
              onChange={handleChange}
              required
            >
              {Object.values(GOAL_TYPE).map((goal) => (
                <option key={goal} value={goal}>{goal}</option>
              ))}
            </select>
          </div>
          <Input
            label="Target Weight (kg)"
            type="number"
            name="targetWeight"
            value={formData.targetWeight}
            onChange={handleChange}
            required
          />
          <Button type="submit">Create Goal</Button>
        </form>
      </div>
  );
};

export default LoginForm;