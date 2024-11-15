import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../../hooks/useAuth';
import RegisterForm from './RegisterForm';

export default function Register() {
  const navigate = useNavigate();
  const { token, successMessage } = useAuth();

  useEffect(() => {
    if (token) {
      navigate('/', { replace: true });
    }
  }, [token, navigate]);

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-900"
      style={{
        backgroundImage:'url(/images/loginbg.png)',
        backgroundSize: 'cover',
        backgroundPosition: 'center'
      }}>
      <div className="w-full max-w-md">
        {successMessage && <p className="text-green-500 text-center">{successMessage}</p>}
        <RegisterForm />
        <p className="text-sm text-center text-gray-600">
          Already have an account?{' '}
          <a href="/login" className="text-blue-600 hover:underline hover:text-blue-800">
            Login
          </a>
        </p>
      </div>
    </div>
  );
}