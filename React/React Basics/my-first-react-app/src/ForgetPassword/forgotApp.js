import React, { useState } from 'react';

const App = () => {
    const [step, setStep] = useState(1);
    const [email, setEmail] = useState('');
    const [securityDetails, setSecurityDetails] = useState(null);
    const [answer, setAnswer] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [message, setMessage] = useState('');

    const handleEmailSubmit = () => {
        // Simulate API request to fetch security details
        if (email === 'user@example.com') {
            setSecurityDetails({
                question: 'What is your favorite color?',
                answer: 'blue',
            });
            setStep(2);
        } else {
            setMessage('Email not found.');
        }
    };

    const handleAnswerSubmit = () => {
        if (answer === securityDetails.answer) {
            setStep(3);
        } else {
            setMessage('Incorrect answer.');
        }
    };

    const handlePasswordUpdate = () => {
        if (newPassword === confirmPassword) {
            // Simulate success
            setMessage('Password updated successfully.');
        } else {
            setMessage('Passwords do not match.');
        }
    };

    const renderStep = () => {
        switch (step) {
            case 1:
                return (
                    <div>
                        <p>Step 1: Enter your email</p>
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
                        <button onClick={handleEmailSubmit}>Submit</button>
                        <p>{message}</p>
                    </div>
                );
            case 2:
                return (
                    <div>
                        <p>Step 2: Answer your security question</p>
                        <p>Security Question: {securityDetails.question}</p>
                        <input
                            type="text"
                            value={answer}
                            onChange={(e) => setAnswer(e.target.value)}
                        />
                        <button onClick={handleAnswerSubmit}>Submit</button>
                        <p>{message}</p>
                    </div>
                );
            case 3:
                return (
                    <div>
                        <p>Step 3: Update your password</p>
                        <input
                            type="password"
                            placeholder="New Password"
                            value={newPassword}
                            onChange={(e) => setNewPassword(e.target.value)}
                        />
                        <input
                            type="password"
                            placeholder="Confirm Password"
                            value={confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}
                        />
                        <button onClick={handlePasswordUpdate}>Update Password</button>
                        <p>{message}</p>
                    </div>
                );
            default:
                return null;
        }
    };

    return (
        <div>
            <h1>Forgot Password</h1>
            {renderStep()}
        </div>
    );
};

export default App;
