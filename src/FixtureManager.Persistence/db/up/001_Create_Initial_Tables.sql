CREATE TABLE fixture (
    id BIGSERIAL PRIMARY KEY,
    date_time TIMESTAMP NOT NULL,
    location VARCHAR(255) NOT NULL
);

CREATE TABLE school (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    province VARCHAR(255) NOT NULL
);

CREATE TABLE user_details (
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    password_hash TEXT NOT NULL,
    email VARCHAR(255) NOT NULL,
    mobile_number VARCHAR(255) NOT NULL,
    country_code VARCHAR(10) NOT NULL,
    school_id BIGINT NOT NULL,
    type INT NOT NULL,

    FOREIGN KEY (school_id) REFERENCES school(id) ON DELETE CASCADE
);

CREATE TABLE team (
    id BIGSERIAL PRIMARY KEY,
    coach_id BIGINT NOT NULL,
    sport_id BIGINT NOT NULL,
    school_id BIGINT NOT NULL,
    team_name VARCHAR(255) NOT NULL,
    age_group VARCHAR(255) NOT NULL,
    
    FOREIGN KEY (coach_id) REFERENCES user_details(id) ON DELETE CASCADE,
    FOREIGN KEY (school_id) REFERENCES school(id) ON DELETE CASCADE
);

CREATE TABLE team_list (
    team_id BIGINT NOT NULL,
    fixture_id BIGINT NOT NULL,
    student_id BIGINT NOT NULL,
    position_details TEXT NOT NULL,
    
    FOREIGN KEY (team_id) REFERENCES team(id) ON DELETE CASCADE,
    FOREIGN KEY (fixture_id) REFERENCES fixture(id) ON DELETE CASCADE,
    FOREIGN KEY (student_id) REFERENCES user_details(id) ON DELETE CASCADE,
    
    PRIMARY KEY (team_id, fixture_id, student_id)
);