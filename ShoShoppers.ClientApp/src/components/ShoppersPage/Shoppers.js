import React, { Component } from 'react';
import { NavMenu } from '../Header/NavMenu';
import { Footer } from '../Footer/Footer';
import { itemsColors } from "../ItemsForSaleRendering/ColorsData"
import { RenderItemsPage } from '../ItemsForSaleRendering/RenderItemsPage';
import { Loading } from '../LoadingScreen/Loading';
import { motion } from 'framer-motion';

export class Shoppers extends Component {
    static displayName = Shoppers.name;

    constructor(props) {
        super(props);

        this.state = {shoppers: [], loading: true};
    }

    static renderShoppers(shoppers) {
        return (
            <motion.div
                className="relative min-h-screen"
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
            >
                <NavMenu />
                <RenderItemsPage _itemLabel="В наявності" _showItemColorFilterOption="шопера" _renderItemsColors={itemsColors} _items={shoppers} _showShoppers={true} />
                <Footer />
            </motion.div>
        );
    }

    componentDidMount() {
        this.loadShoppers();
    }

    render() {
        let contents = this.state.loading ? <Loading /> : Shoppers.renderShoppers(this.state.shoppers);

        return (
            <motion.div
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
            >
                {contents}
            </motion.div>
        );
    }

    async loadShoppers() {
        const response = await fetch('/api/Shopper');
        const data = await response.json();
        this.setState({shoppers: data, loading: false});
    }
}