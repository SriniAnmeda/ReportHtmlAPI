// src/KeycloakService.js
import Keycloak from 'keycloak-js';

const keycloak = new Keycloak({
    url: 'http://localhost:8080/auth',
    realm: 'HtmlReportRealm',
    clientId: 'html-report-app'
});

const KeycloakService = {
    initKeycloak(onAuthenticatedCallback) {
        keycloak.init({ onLoad: 'login-required' }).then((authenticated) => {
            if (authenticated) {
                console.log('Authenticated');
                onAuthenticatedCallback();
            } else {
                window.location.reload();
            }
        }).catch((error) => {
            console.error('Authentication Failed:', error);
        });
    },
    login() {
        keycloak.login();
    },
    logout() {
        keycloak.logout();
    },
    getToken() {
        return keycloak.token;
    },
    isLoggedIn() {
        return !!keycloak.token;
    },
    updateToken() {
        return keycloak.updateToken(30).then(() => {
            return keycloak.token;
        }).catch(() => {
            console.error('Failed to refresh token');
            this.logout();
        });
    },
    getUsername() {
        return keycloak.tokenParsed?.preferred_username;
    }
};

export default KeycloakService;
