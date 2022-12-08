import React, { Component } from 'react';
import ReviewsSlider from './ReviewsSlider';
import { Loading } from '../LoadingScreen/Loading';

export default class Reviews extends Component {
    static displayName = Reviews.name;

    constructor(props) {
        super(props);

        this.state = {reviews: [], loading: true};
    }

    static renderReviews(reviews) {
        return (
            <div className="flex">
                <div className="bg-[#3ba144] h-auto w-full my-8 flex justify-around align-center mb-8 lg:mb-16 md:mt-20 lg:mt-0">
                    <div className="p-2 my-auto flex flex-col w-full items-center justify-center sm:h-fit">
                        <div className="mt-6 flex w-full items-center justify-center">
                            <fieldset className="border-4 h-fit w-[375px] sm:w-[500px] lg:w-[820px] xl:w-[1140px] flex justify-center drop-shadow-2xl rounded-lg pb-2">
                                <legend className="text-white text-3xl text-left ml-12 px-2 select-none">Відгуки</legend>
                                <ReviewsSlider reviews={reviews} />
                            </fieldset>
                        </div>
                        <div className="flex justify-center py-8">
                            <button className="w-56 h-16 text-[#038C25] bg-white font-medium rounded-full text-2xl shadow-xl hover:bg-gray-200 hover:ease-in hover:duration-300 duration-300">
                                <a href="https://www.instagram.com/sho_shoper_/" target="_blank" rel="noopener noreferrer" className="drop-shadow-lg select-none">Більше відгуків</a>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    componentDidMount() {
        this.loadReviews();
    }

    render() {
        let contents = this.state.loading ? <Loading /> : Reviews.renderReviews(this.state.reviews);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async loadReviews() {
        const response = await fetch('/api/Review');
        const data = await response.json();
        this.setState({reviews: data, loading: false});
    }
}