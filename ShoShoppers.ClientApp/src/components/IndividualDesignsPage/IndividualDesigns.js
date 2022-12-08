import React, { Component } from 'react';
import { NavMenu } from '../Header/NavMenu';
import { Footer } from '../Footer/Footer';
import { itemsColors } from "../ItemsForSaleRendering/ColorsData"
import { RenderItemsPage } from '../ItemsForSaleRendering/RenderItemsPage';
import { Loading } from '../LoadingScreen/Loading';
import { motion } from 'framer-motion';

export class IndividualDesigns extends Component {
    static displayName = IndividualDesigns.name;

    constructor(props) {
        super(props);

        this.state = {individualDesigns: [], loading: true};
    }

    static renderindividualDesigns(individualDesigns) {
        return (
            <motion.div
                className="relative min-h-screen"
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
            >
                <NavMenu />
                <RenderItemsPage _itemLabel="Індивідуальний дизайн" _showItemColorFilterOption="шопера" _renderItemsColors={itemsColors} _items={individualDesigns} _showIndividual={true} />
                <Footer />
            </motion.div>
        );
    }

    componentDidMount() {
        this.loadIndividualDesigns();
    }

    render() {
        let contents = this.state.loading ? <Loading /> : IndividualDesigns.renderindividualDesigns(this.state.individualDesigns);

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

    async loadIndividualDesigns() {
        const response = await fetch('/api/IndividualDesign');
        const data = await response.json();
        this.setState({individualDesigns: data, loading: false});
    }
}