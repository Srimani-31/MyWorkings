import React, { useState } from 'react';

const ForgotPasswordForm = ({ onEmailSubmit }) => {
    const [email, setEmail] = useState('');
    const [isValid, setIsValid] = useState(false);

    const handleEmailChange = (e) => {
        const newEmail = e.target.value;
        setEmail(newEmail);
        // Perform email validation here and update isValid state accordingly
        setIsValid(/* perform validation */);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (isValid) {
            onEmailSubmit(email);
        }
    };
    const handleEmailSubmit = async (email) => {
        try {
            const response = await fetch(`/api/getsecuritydetailsbyemail/${email}`);
            if (response.ok) {
                const securityDetails = await response.json();
                // Process securityDetails and render security questions
            } else {
                // Handle error (e.g., email not found)
            }
        } catch (error) {
            // Handle network or other errors
        }
    };
    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Email:</label>
                <input
                    type="email"
                    value={email}
                    onChange={handleEmailChange}
                    required
                />
                {isValid ? null : <div>Email is not valid.</div>}
            </div>
            <button type="submit" disabled={!isValid}>
                Verify Email
            </button>
        </form>
    );
};

export default ForgotPasswordForm;