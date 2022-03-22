CREATE TABLE `donstringham`.`blabs`
(
    `id`            INT           NOT NULL AUTO_INCREMENT,
    `sys_id`        CHAR(16)      NOT NULL,
    `dttm_created`  DATETIME      NOT NULL DEFAULT NOW(),
    `dttm_modified` DATETIME      NOT NULL DEFAULT NOW(),
    `content`       VARCHAR(1024) NULL,
    `usr`           VARCHAR(45)   NOT NULL,
    PRIMARY KEY (`id`),
    UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
    UNIQUE INDEX `sys_id_UNIQUE` (`sys_id` ASC) VISIBLE
);

INSERT INTO `donstringham`.`blabs` (sys_id, dttm_created, dttm_modified, content, usr)
VALUES ("712646ae-7ce0-416f-9c25-55c7bbe95fce", "2022-03-14 09:09:09", "2022-03-14 09:09:09",
        "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", "foobar");

SELECT sys_id, dttm_created, dttm_modified, content, usr
FROM `donstringham`.`blabs`
WHERE `donstringham`.`blabs`.`sys_id` LIKE "9a31a7f8-8bd4-45e6-ba8f-4d5bb47588bd";

SELECT *
FROM `donstringham`.`blabs`;

TRUNCATE `donstringham`.`blabs`;

CREATE TABLE `donstringham`.`user`
(
    `id`             INT         NOT NULL AUTO_INCREMENT,
    `sys_id`         VARCHAR(45) NOT NULL,
    `dttm_created`   DATETIME    NULL,
    `dttm_lastlogin` DATETIME    NULL,
    `email`          VARCHAR(45) NOT NULL,
    `username`       VARCHAR(45) NOT NULL,
    `first_name`     VARCHAR(45) NOT NULL,
    `last_name`      VARCHAR(45) NOT NULL,
    PRIMARY KEY (`id`),
    UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
    UNIQUE INDEX `sys_id_UNIQUE` (`sys_id` ASC) VISIBLE,
    UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE
);

SELECT sys_id, dttm_lastlogin, email, username, first_name, last_name
FROM `donstringham`.`user`
WHERE `donstringham`.`user`.`sys_id` LIKE "9a31a7f8-8bd4-45e6-ba8f-4d5bb47588bd";

SELECT sys_id, dttm_lastlogin, email, username, first_name, last_name
FROM `donstringham`.`user`
WHERE `donstringham`.`user`.`username` LIKE "foobar";

SELECT *
FROM `donstringham`.`user`;

TRUNCATE `donstringham`.`user`;