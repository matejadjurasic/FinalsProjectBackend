import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../../hooks/useAuth';
import LoginForm from './LoginForm';

export default function Login() {
  const navigate = useNavigate();
  const { token, successMessage } = useAuth();

  useEffect(() => {
    if (token) {
      navigate('/', { replace: true });
    }
  }, [token, navigate]);

  return (
    <div className="flex items-center justify-center min-h-screen"
        style={{
          backgroundImage:'url(/images/loginbg.png)',
          backgroundSize: 'cover',
          backgroundPosition: 'center'
        }}>
      <div className="w-full max-w-md">
        {successMessage && <p className="text-green-500 text-center">{successMessage}</p>}
        <LoginForm />
        <p className="text-sm text-center text-gray-400">
          Don't have an account?{' '}
          <a href="/register" className="text-blue-400 hover:underline hover:text-blue-300">
            Register
          </a>
        </p>
      </div>
    </div>
  );
}