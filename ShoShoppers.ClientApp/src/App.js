import React from 'react';
import AnimatedRoutes from './AnimatedRoutes';
import { Layout } from './components/Layout';

export const App = () => {
    if (localStorage.getItem("tokenExpirationTime") != null && new Date().getTime() - localStorage.getItem("tokenExpirationTime") > 172800000) {
        localStorage.removeItem("cart");
        localStorage.removeItem("tokenExpirationTime");
        localStorage.removeItem("UserToken");
    }

    return (
        <Layout>
            <AnimatedRoutes />
        </Layout>
    );
}

export default App;
