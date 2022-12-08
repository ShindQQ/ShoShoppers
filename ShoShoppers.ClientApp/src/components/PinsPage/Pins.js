import React, { Component } from 'react';
import { NavMenu } from '../Header/NavMenu';
import { Footer } from '../Footer/Footer';
import { pinsColors} from "../ItemsForSaleRendering/ColorsData"
import { RenderItemsPage } from '../ItemsForSaleRendering/RenderItemsPage';
import { Loading } from '../LoadingScreen/Loading';
import { motion } from 'framer-motion';

export class Pins extends Component {
    static displayName = Pins.name;

    constructor(props) {
        super(props);

        this.state = {pins: [], loading: true};
    }

    static renderPins(pins) {
        return (
            <motion.div
                className="relative min-h-screen"
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
            >
                <NavMenu />
                <RenderItemsPage _itemLabel="Піни" _showItemColorFilterOption="основи" _renderItemsColors={pinsColors} _items={pins} _showPins={true} />
                <Footer />
            </motion.div>
        );
    }

    componentDidMount() {
        this.loadPins();
    }

    render() {
        let contents = this.state.loading ? <Loading /> : Pins.renderPins(this.state.pins);

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

    async loadPins() {
        const response = await fetch('/api/Pin');
        const data = await response.json();
        this.setState({pins: data, loading: false});
    }
}