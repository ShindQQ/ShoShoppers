import React, { Component } from 'react';
import { NavMenu } from '../Header/NavMenu';
import { Footer } from '../Footer/Footer';
import { Orders } from './Orders';

export class OrdersPage extends Component {
    static displayName = OrdersPage.name;

    render() {
        return (
            <div className="relative min-h-screen">
                <NavMenu />
                <Orders />
                <Footer />
            </div>
        );
    }
}
