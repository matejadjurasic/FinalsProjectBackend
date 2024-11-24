import React, { useState, useEffect } from 'react';
import { User } from '../../lib/types';
import Button from '../common/Button';
import ErrorDisplay from '../error/ErrorDisplay';
import { useSelector, useDispatch } from 'react-redux';
import { clearUserErrors, updateUser } from '../../store/slices/usersSlice';
import { updateUser as updateUserInAuth } from '../../store/slices/authSlice';
import { AppDispatch } from '../../store';
import { GENDER } from '../../lib/constants';

interface UpdateUserModalProps {
    isOpen: boolean;
    onClose: () => void;
    user: User;
}

const UpdateUserModal: React.FC<UpdateUserModalProps> = ({ isOpen, onClose, user }) => {
    const dispatch = useDispatch<AppDispatch>();
    const [updatedUser, setUpdatedUser] = useState<User>(user);
    const errors = useSelector((state: any) => state.users.error);
    const validationErrors = useSelector((state: any) => state.users.validationError);

    useEffect(() => {
        setUpdatedUser(user);
    }, [user]);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setUpdatedUser((prevState) => ({ ...prevState, [name]: value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        const result = await dispatch(updateUser({ id: user?.id ?? 0, userData: updatedUser }));
        if (updateUser.fulfilled.match(result)) {
            dispatch(updateUserInAuth(updatedUser));
            onClose();
        }
    };

    const handleClose = () => {
        dispatch(clearUserErrors());
        setUpdatedUser(user);
        onClose();
    };

    if (!isOpen || !user) return null;

    return (
        <div className="text-black z-40 fixed inset-0 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-gray-800 p-6 rounded shadow-md w-96">
                <h2 className="text-lg text-gray-100 font-bold mb-4">Update User Info</h2>
                <ErrorDisplay error={errors} validationErrors={validationErrors}/>
                <form onSubmit={handleSubmit}>
                    <h3 className='text-gray-100 text-sm font-semibold'>Username:</h3>
                    <input
                        type="text"
                        name="username"
                        value={updatedUser.username}
                        onChange={handleChange}
                        placeholder="Username"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Email:</h3>
                    <input
                        type="email"
                        name="email"
                        value={updatedUser.email}
                        onChange={handleChange}
                        placeholder="Email"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Name:</h3>
                    <input
                        type="text"
                        name="name"
                        value={updatedUser.name}
                        onChange={handleChange}
                        placeholder="Name"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Height:</h3>
                    <input
                        type="number"
                        name="height"
                        value={updatedUser.height}
                        onChange={handleChange}
                        placeholder="Height (cm)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Weight:</h3>
                    <input
                        type="number"
                        name="weight"
                        value={updatedUser.weight}
                        onChange={handleChange}
                        placeholder="Weight (kg)"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Age:</h3>
                    <input
                        type="number"
                        name="age"
                        value={updatedUser.age}
                        onChange={handleChange}
                        placeholder="Age"
                        className="border rounded p-2 mb-2 w-full"
                        required
                    />
                    <h3 className='text-gray-100 text-sm font-semibold'>Gender:</h3>
                    <select
                        name="gender"
                        value={updatedUser.gender}
                        onChange={handleChange}
                        className="border rounded p-2 mb-4 w-full"
                    >
                        {Object.values(GENDER).map((goalType) => (
                            <option key={goalType} value={goalType}>{goalType}</option>
                        ))}
                    </select>
                    <div className="flex justify-end">
                        <Button type="button" onClick={handleClose} className="mr-2 text-gray-500">Cancel</Button>
                        <Button type="submit" variant='primary'>Update</Button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default UpdateUserModal;