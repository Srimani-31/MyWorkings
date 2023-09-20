// SecurityQuestionForm.js

import React, { useState } from 'react';

const SecurityQuestionForm = ({ securityQuestion, onAnswerSubmit }) => {
    const [answer, setAnswer] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onAnswerSubmit(answer);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <p>Security Question:</p>
                <p>{securityQuestion}</p>
            </div>
            <div>
                <label>Answer:</label>
                <input
                    type="text"
                    value={answer}
                    onChange={(e) => setAnswer(e.target.value)}
                    required
                />
            </div>
            <button type="submit">Submit Answer</button>
        </form>
    );
};

export default SecurityQuestionForm;