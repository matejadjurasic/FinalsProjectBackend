import React, { useState, useRef, useEffect } from 'react';
import { Link } from 'react-router-dom';
import Dropdown from './Dropdown';
import { logout } from '../../store/slices/authSlice';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import Button from './Button';

interface NavbarProps {
    items : { label: string, path: string }[];
}

const Navbar: React.FC<NavbarProps> = ({items}) => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [isUserMenuOpen, setUserMenuOpen] = useState(false);
    const userMenuRef = useRef<HTMLDivElement>(null);

    const toggleUserMenu = () => setUserMenuOpen((prev) => !prev);

    const handleClickOutside = (event: MouseEvent) => {
        if (userMenuRef.current && !userMenuRef.current.contains(event.target as Node)) {
          setUserMenuOpen(false);
        }
    };

    useEffect(() => {
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
          document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    const handleLogout = () => {
        dispatch(logout());
        navigate('/login', { replace: true });
    };

  return (
    <nav className="flex items-center justify-between p-4 bg-gray-900 text-white bg-opacity-30 absolute w-full">
      <div className="flex space-x-4">
        {items.map((item) => (
          <Link key={item.label} to={item.path} className="text-gray-100 hover:text-gray-300 no-underline">
            {item.label}
          </Link>
        ))}
      </div>
      <div className="relative" ref={userMenuRef}>
        <Button 
            onClick={toggleUserMenu} 
            className="flex items-center">
            <div className="w-8 h-8 rounded-full bg-gray-300 flex items-center justify-center text-white">
                U 
            </div>
        </Button>
        <Dropdown isOpen={isUserMenuOpen} onClose={() => setUserMenuOpen(false)} direction='right'>
          <Link to="/profile" className='no-underline'>
              <Button 
                  className="text-gray-800 block w-full text-left px-4 py-2 hover:bg-gray-200">
                  Edit User
              </Button>
          </Link>
              <Button 
                  onClick={handleLogout} 
                  className="text-red-600 block w-full text-left px-4 py-2 hover:bg-gray-200">
                  Logout
              </Button>
        </Dropdown>

      </div>
    </nav>
  )
}

export default Navbar;