// src/App.js
import React, { useEffect, useState } from 'react';
import KeycloakService from './KeycloakService';

function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [username, setUsername] = useState('');

    useEffect(() => {
        KeycloakService.initKeycloak(() => {
            setIsAuthenticated(true);
            setUsername(KeycloakService.getUsername());
        });
    }, []);

    const handleLogin = () => {
        KeycloakService.login();
    };

    const handleLogout = () => {
        KeycloakService.logout();
    };

    return (
        <div>
            <h1>Keycloak Auth with React</h1>
            {isAuthenticated ? (
                <div>
                    <h2>Welcome, {username}</h2>
                    <button onClick={handleLogout}>Logout</button>
                </div>
            ) : (
                <button onClick={handleLogin}>Login</button>
            )}
        </div>
    );
}

export default App;
