import { fetchUtils } from 'react-admin';

export const httpClient = (url, options = {}) => {
    if (!options.headers) {
        options.headers = new Headers({Accept: 'application/json'});
    }
    const { token } = JSON.parse(localStorage.getItem('auth'));
    options.headers.set('Authorization', `Bearer ${ token }`);
    return fetchUtils.fetchJson(url, options);
};