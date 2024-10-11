import React from 'react';
import { useDispatch } from 'react-redux';
import { logout } from '../store/slices/authSlice';
import { useNavigate } from 'react-router-dom';
import Button from './common/Button';
import { useAuth } from '../hooks/useAuth';

export default function Home() {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { user } = useAuth();

  const handleLogout = () => {
    dispatch(logout());
    navigate('/login', { replace: true });
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-100">
      <div className="max-w-xl p-8 bg-white rounded shadow-md">
        <h2 className="mb-4 text-2xl font-bold text-gray-800">
          Welcome, {user?.name}!
        </h2>
        <div className="space-y-2">
          <p>
            <strong>Email:</strong> {user?.email}
          </p>
          <p>
            <strong>Username:</strong> {user?.username}
          </p>
          <p>
            <strong>Height:</strong> {user?.height} cm
          </p>
          <p>
            <strong>Weight:</strong> {user?.weight} kg
          </p>
          <p>
            <strong>Age:</strong> {user?.age}
          </p>
          <p>
            <strong>Gender:</strong> {user?.gender}
          </p>
          <p>
            <strong>Roles:</strong> {user?.roles.join(', ')}
          </p>
        </div>
        <Button variant="danger" onClick={handleLogout}>
          Logout
        </Button>
      </div>
    </div>
  );
}
