export default {
    setReady(state, value) {
        state.ready = value;
    },
    setUserFromDB(state, requestData) {
        state.user = {
            userName: requestData.userName,
            email: requestData.email,
            phoneNumber: requestData.phoneNumber,
            id: requestData.id
        };
    },
    setSemesters(state, requestData) {
        state.semesters = requestData;
    },
    clearUser(state) {
        state.user = {};
    },
    initUser(state, requestData) {
        this.setUserFromDB(state, requestData.user);

    }
}