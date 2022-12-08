﻿export const PageNotFound = () => {
    return (
        <div className="w-full h-screen bg-[#3ba144] relative">
            <div className="absolute bottom-0 -top-24 w-full flex justify-center items-center drop-shadow-lg z-0">
                <svg className="h-72 text-white drop-shadow-lg" fill="currentColor" viewBox="0 0 93.81 122.88" aria-hidden="true">
                    <path fillRule="evenodd"
                        d="M28.98,31.32v-9.74h-0.01c0-4.72,1.94-9.02,5.05-12.13c3.12-3.12,7.41-5.06,12.13-5.06V4.4h0.03V4.39 c4.72,0,9.02,1.94,12.13,5.05c3.12,3.12,5.05,7.41,5.06,12.13h-0.01v9.86c-2.09,0.69-3.6,2.65-3.6,4.97c0,2.89,2.34,5.24,5.24,5.24 c2.89,0,5.24-2.35,5.24-5.24c0-1.88-0.99-3.52-2.47-4.44V21.57h-0.01c-0.01-5.93-2.43-11.32-6.33-15.22 c-3.91-3.91-9.31-6.34-15.24-6.34V0l-0.03,0v0.01c-5.93,0-11.32,2.43-15.22,6.33c-3.91,3.91-6.34,9.31-6.34,15.24h-0.01v10.65 c-1.26,0.96-2.08,2.47-2.08,4.17c0,2.89,2.35,5.24,5.24,5.24c2.89,0,5.24-2.35,5.24-5.24C32.98,33.94,31.27,31.88,28.98,31.32 L28.98,31.32L28.98,31.32z M10.99,31.49h6.56c-0.86,1.61-1.36,3.46-1.36,5.42c0,0.68,0.06,1.34,0.17,1.98h-3.23l-5.56,76.59h78.67 l-5.56-76.59h-4.6c0.11-0.64,0.17-1.31,0.17-1.98c0-1.96-0.49-3.8-1.36-5.42h7.92c1.41,0,2.64,0.57,3.55,1.48 c0.88,0.88,1.44,2.07,1.53,3.36l5.89,81.19c0.01,0.16,0.02,0.28,0.02,0.35c0,1.39-0.59,2.62-1.5,3.52c-0.85,0.83-2,1.38-3.24,1.47 c-0.16,0.01-0.29,0.02-0.36,0.02H5.1c-0.07,0-0.2-0.01-0.36-0.02c-1.23-0.09-2.39-0.63-3.24-1.47c-0.92-0.9-1.5-2.13-1.5-3.53 c0-0.07,0.01-0.18,0.02-0.35l5.89-81.19c0.09-1.29,0.65-2.48,1.53-3.36C8.36,32.06,9.59,31.49,10.99,31.49L10.99,31.49z M37.81,31.49h16.83c-0.86,1.61-1.36,3.46-1.36,5.42c0,0.68,0.06,1.34,0.17,1.98H38.99c0.11-0.64,0.17-1.31,0.17-1.98 C39.17,34.95,38.67,33.11,37.81,31.49L37.81,31.49z"
                        clipRule="evenodd" />
                </svg>
            </div>
            <div className="absolute bottom-0 -top-10 text-[5.5rem] text-white flex flex-col justify-center align-center items-center w-full mt-2 select-none drop-shadow-lg">
                <b className="drop-shadow-lg">404</b>
            </div>
            <div className="absolute bottom-0 top-80 text-3xl text-white flex flex-col justify-center align-center items-center w-full mt-2 select-none drop-shadow-lg z-50">
                <b className="drop-shadow-lg">Сторінка не знайдена!</b>
                <a href="/" className="drop-shadow-lg underline mt-4"><b>Перейти на головну</b></a>
            </div>
        </div>
    );
};
