export const authProvider = {
    login: ({username, password}) => {
        const request = new Request('/api/Authentication', {
            method: 'POST',
            body: JSON.stringify({username, password}),
            headers: new Headers({'Content-Type': 'application/json'}),
        });
        return fetch(request)
            .then(response => {
                if (response.status < 200 || response.status >= 300) {
                    throw new Error(response.statusText);
                }
                return response.json();
            })
            .then(auth => {
                localStorage.setItem('auth', JSON.stringify(auth));
            })
            .catch(() => {
                throw new Error('Network error')
            });
    },
    logout: () => {
        localStorage.removeItem('auth');
        return Promise.resolve();
    },
    checkAuth: () => {
        return localStorage.getItem('auth') ? Promise.resolve() : Promise.reject();
    },
    checkError: (error) => {
        const status = error.status;
        if (status === 401 || status === 403) {
            localStorage.removeItem('auth');
            return Promise.reject({message: false});
        }
        return Promise.resolve();
    },
    getPermissions: () => {
        return Promise.resolve();
    },
    getIdentity: () => {
        try {
            const {username} = JSON.parse(localStorage.getItem('auth'));
            return Promise.resolve({fullName: username});
        } catch (error) {
            return Promise.reject(error);
        }
    }
};