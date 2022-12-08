import simpleRestDataProvider from 'ra-data-simple-rest';
import { httpClient } from './httpClient'

const baseDataProvider = simpleRestDataProvider('/api', httpClient);

export const dataProvider = {
    ...baseDataProvider,
    sendEmails: (subject, htmlBody) => {
        const {token} = JSON.parse(localStorage.getItem('auth'));
        return fetch(`/api/Email/SendEmails`, {
            method: 'POST',
            headers: new Headers({
                'authorization': `Bearer ${token}`,
                'Content-Type': 'application/json-patch+json'
            }),
            body: JSON.stringify({
                'subject': subject,
                'htmlBody': htmlBody
            })
        }).then(response => response.json());
    },
}