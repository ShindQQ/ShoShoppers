import React, { Component } from 'react';
import { NavMenu } from './Header/NavMenu';
import { Body } from './Body/Body';
import { Footer } from './Footer/Footer';
import { motion } from 'framer-motion';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <motion.div
                className="relative min-h-screen"
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
            >
                <NavMenu />
                <Body />
                <Footer />
            </motion.div>
        );
    }
}
