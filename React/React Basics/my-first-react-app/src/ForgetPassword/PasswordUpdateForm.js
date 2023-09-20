// PasswordUpdateForm.js

import React, { useState } from 'react';

const PasswordUpdateForm = ({ onUpdatePassword }) => {
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onUpdatePassword(password, confirmPassword);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>New Password:</label>
                <input
                    type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Confirm Password:</label>
                <input
                    type="password"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    required
                />
            </div>
            <button type="submit">Update Password</button>
        </form>
    );
};

export default PasswordUpdateForm;