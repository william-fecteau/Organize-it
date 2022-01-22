export default {
    isUserLoggedIn: state => {
        return !!state.user.id;
    }
}