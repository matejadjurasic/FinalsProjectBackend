import React from 'react';
import Button from '../../common/Button';
import Input from '../../common/Input';
import { useLogin } from '../../../hooks/useLogin';
import ErrorDisplay from '../../error/ErrorDisplay';

const LoginForm: React.FC = () => {
  const { email, setEmail, password, setPassword, loading, error, validationErrors, handleSubmit } = useLogin();

  return (
    <div className="w-full max-w-md p-8 space-y-4 bg-gray-800 rounded shadow-md">
      <h2 className="text-2xl font-bold text-center text-white">Login</h2>
      <ErrorDisplay error={error} validationErrors={validationErrors} />
      <form onSubmit={handleSubmit} className="space-y-4">
        <Input
          label="Email"
          type="email"
          id="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        <Input
          label="Password"
          type="password"
          id="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
        <Button type="submit" isLoading={loading}>
          Login
        </Button>
      </form>
    </div>
  );
};

export default LoginForm;