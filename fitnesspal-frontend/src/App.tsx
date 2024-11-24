import React from 'react';
import { BrowserRouter as Router, Route, Routes,Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { RootState } from './store';
import Login from './components/auth/login/Login';
import Register from './components/auth/register/Register';
import Onboarding from './components/auth/onboarding/Onboarding';
import Home from './components/home/Home';
import RequireAuth from './components/auth/RequireAuth';
import './App.css';
import Log from './components/logPage/Log';
import Stats from './components/stats/Stats';
import Profile from './components/profile/Profile';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const { token } = useSelector((state: RootState) => state.auth);

  return (
    <Router>
      <Routes>
        {/* Protected Route */}
        <Route
          path="/"
          element={
            <RequireAuth>
              <Home />
            </RequireAuth>
          }
        />
        <Route
          path="/onboarding"
          element={
            <RequireAuth>
              <Onboarding />
            </RequireAuth>
          }
        />
        <Route
          path="/log"
          element={
            <RequireAuth>
              <Log />
            </RequireAuth>
          }
        />
        <Route
          path="/stats"
          element={
            <RequireAuth>
              <Stats />
            </RequireAuth>
          }
        />
        <Route
          path="/profile"
          element={
            <RequireAuth>
              <Profile />
            </RequireAuth>
          }
        />
      {/* Public Routes */}
      <Route
        path="/login"
        element={!token ? <Login /> : <Navigate to="/" replace />}
      />
      <Route
        path="/register"
        element={!token ? <Register /> : <Navigate to="/" replace />}
      />
      {/* Catch-all Route */}
      <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Router>
  );
}

export default App;
