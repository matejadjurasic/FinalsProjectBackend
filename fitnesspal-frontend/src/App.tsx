import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link,Navigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { RootState } from './store';
import Login from './components/Login';
import Register from './components/Register';
import Home from './components/Home';
import RequireAuth from './components/RequireAuth';
import './App.css';

function App() {
  const { token } = useSelector((state: RootState) => state.auth);

  return (
    <Router>
    <nav className="p-4 bg-blue-600">
    <div className="container mx-auto">
          <Link to="/" className="text-white hover:underline">
            Home
          </Link>
          {!token && (
            <>
              {' '}
              |{' '}
              <Link to="/login" className="text-white hover:underline">
                Login
              </Link>{' '}
              |{' '}
              <Link to="/register" className="text-white hover:underline">
                Register
              </Link>
            </>
          )}
        </div>
    </nav>
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
