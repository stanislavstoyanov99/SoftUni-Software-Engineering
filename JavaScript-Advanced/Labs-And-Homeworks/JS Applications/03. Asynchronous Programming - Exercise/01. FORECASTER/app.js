function attachEvents() {
    const elements = {
        getLocation() { return document.getElementById('location') },
        getWeatherButton() { return document.getElementById('submit') },
        getForecastSection() { return document.getElementById('forecast') },
        currentConditions() { return document.getElementById('current') },
        upcomingConditions() { return document.getElementById('upcoming') }
    };

    const initialCurrentDivState = elements.currentConditions().cloneNode(true);
    const initialUpcomingDivState = elements.upcomingConditions().cloneNode(true);

    elements.getWeatherButton().addEventListener('click', onGetWeather);

    const baseUrl = 'https://judgetests.firebaseio.com/';
    const weatherSymbols = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176'
    };
    const degreesSymbol = weatherSymbols['Degrees'];

    function onGetWeather(e) {
        e.preventDefault();
        elements.currentConditions().innerHTML = initialCurrentDivState.innerHTML;
        elements.upcomingConditions().innerHTML = initialUpcomingDivState.innerHTML;

        fetch(baseUrl + 'locations.json')
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                }

                return response.json();
            })
            .then(data => showForecastSection(data))
            .catch(error => handleError(error));
    }

    function showForecastSection(data) {
        const inputLocation = elements.getLocation().value;

        if (!Object.values(data).some(x => x.name == inputLocation)) {
            handleError();
            return;
        }

        const location = Object.values(data).find(x => x.name == inputLocation);
        const code = location.code;

        getCurrentConditions(code);
        getUpcomingConditions(code);
    }

    function getCurrentConditions(code) {
        const url = baseUrl + `forecast/today/${code}.json`;

        fetch(url)
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                }

                return response.json();
            })
            .then(data => showCurrentConditions(data))
            .catch(error => handleError(error));
    }

    function showCurrentConditions(data) {
        const { forecast: { condition, high, low }, name } = data;
        const divContainer = document.createElement('div');
        divContainer.setAttribute('class', 'forecasts');

        const spanSymbol = document.createElement('span');
        spanSymbol.setAttribute('class', 'condition symbol');
        spanSymbol.innerHTML = weatherSymbols[condition];
        divContainer.appendChild(spanSymbol);

        const spanCondition = document.createElement('span');
        spanCondition.setAttribute('class', 'condition');

        const spanLocationName = document.createElement('span');
        spanLocationName.setAttribute('class', 'forecast-data');
        spanLocationName.textContent = name;
        spanCondition.appendChild(spanLocationName);

        const spanDegrees = document.createElement('span');
        spanDegrees.setAttribute('class', 'forecast-data');
        spanDegrees.innerHTML = `${low}${degreesSymbol}/${high}${degreesSymbol}`;
        spanCondition.appendChild(spanDegrees);

        const spanConditionName = document.createElement('span');
        spanConditionName.setAttribute('class', 'forecast-data');
        spanConditionName.textContent = condition;
        spanCondition.appendChild(spanConditionName);

        divContainer.appendChild(spanCondition);

        elements.currentConditions().appendChild(divContainer);

        elements.getForecastSection().style.display = 'block';
        elements.getLocation().value = '';
    }

    function getUpcomingConditions(code) {
        const url = baseUrl + `forecast/upcoming/${code}.json`;

        fetch(url)
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                }

                return response.json();
            })
            .then(data => showUpcomingConditions(data))
            .catch(error => handleError(error));
    }

    function showUpcomingConditions(data) {
        const upcomingForecastContainer = document.createElement('div');
        upcomingForecastContainer.setAttribute('class', 'forecast-info');

        const { forecast } = data;

        forecast.forEach(span => {
            const upcomingSpan = document.createElement('span');
            upcomingSpan.setAttribute('class', 'upcoming');

            const conditionSymbol = document.createElement('span');
            conditionSymbol.setAttribute('class', 'symbol');
            conditionSymbol.innerHTML = weatherSymbols[span.condition];
            upcomingSpan.appendChild(conditionSymbol);

            const temperaturesSpan = document.createElement('span');
            temperaturesSpan.setAttribute('class', 'forecast-data');
            temperaturesSpan.innerHTML = `${span.low}${degreesSymbol}/${span.high}${degreesSymbol}`;
            upcomingSpan.appendChild(temperaturesSpan);

            const condition = document.createElement('span');
            condition.setAttribute('class', 'forecast-data');
            condition.textContent = span.condition;
            upcomingSpan.appendChild(condition);

            upcomingForecastContainer.appendChild(upcomingSpan);
        });

        elements.upcomingConditions().appendChild(upcomingForecastContainer);
    }

    function handleError(error) {
        elements.getLocation().value = '';
        elements.getForecastSection().style.display = 'block';
        elements.currentConditions().innerHTML += 'Error';
        elements.upcomingConditions().innerHTML += 'Error';
    }
}

attachEvents();